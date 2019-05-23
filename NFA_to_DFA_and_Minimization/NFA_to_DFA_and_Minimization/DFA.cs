using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NFA_to_DFA_and_Minimization
{
    class DFA
    {
        public List<Tuple<List<long>, List<string>>> Transitions { get; }
        public long StateCount { get; }
        public string[] Alphabet { get; }
        public long InitialState { get; private set; }
        public List<long> FinalStates { get; }
        protected bool Minimized { get; }

        public DFA(List<Tuple<List<long>, List<string>>> transitions,
            string[] alphabet, long initialState, List<long> finalStates, bool minimized = false)
        {
            Transitions = transitions;
            StateCount = transitions.Count();
            Alphabet = alphabet;
            InitialState = initialState;
            FinalStates = finalStates;
            Minimized = minimized;
        }
        public DFA(NFA nfa)
        {
            this.Alphabet = (string[])nfa.Alphabet.Clone();
            InitialState = 0;
            Transitions = new List<Tuple<List<long>, List<string>>>();
            FinalStates = new List<long>();
            List<List<long>> stateSets = new List<List<long>>() { GenerateInitialStateSet(nfa.Transitions, nfa.InitialState) };
            stateSets[0].Sort();
            List<long> neighbours;
            for (int i = 0; i < stateSets.Count; i++)
            {
                Transitions.Add(new Tuple<List<long>, List<string>>(new List<long>(), new List<string>()));
                foreach (string alphabet in Alphabet)
                {
                    neighbours = GetNeighbours(nfa, stateSets[i], alphabet, out bool isFinal);
                    neighbours.Sort();
                    int neighboursIndex = GetStateSetIndex(stateSets, neighbours);
                    if (neighboursIndex == -1)
                    {
                        if (isFinal)
                            FinalStates.Add(stateSets.Count);
                        Transitions[i].Item1.Add(stateSets.Count);
                        Transitions[i].Item2.Add(alphabet);
                        stateSets.Add(neighbours);
                    }
                    else
                    {
                        Transitions[i].Item1.Add(neighboursIndex);
                        Transitions[i].Item2.Add(alphabet);
                    }
                }
            }
            StateCount = stateSets.Count;
            Minimized = false;
        }

        private List<long> GenerateInitialStateSet(Tuple<List<long>, List<string>>[] transitions, long initialState)
        {
            List<long> initialStateSet = new List<long>() { initialState };
            for (int i = 0; i < transitions[initialState].Item1.Count; i++)
            {
                if (transitions[initialState].Item2[i] == "_")
                    initialStateSet.Add(transitions[initialState].Item1[i]);
            }
            return initialStateSet;
        }

        private List<long> GetNeighbours(NFA nfa, List<long> stateSet, string alphabet, out bool isFinal)
        {
            List<long> neighbours = new List<long>();
            List<long> neighboursSeenAlnphabet = new List<long>();
            isFinal = false;
            for (int i = 0; i < stateSet.Count; i++)
            {
                for (int j = 0; j < nfa.Transitions[stateSet[i]].Item1.Count; j++)
                {
                    long neighbour = nfa.Transitions[stateSet[i]].Item1[j];
                    if (nfa.Transitions[stateSet[i]].Item2[j] == alphabet &&
                        !neighbours.Contains(neighbour))
                    {
                        neighbours.Add(neighbour);
                        if (nfa.FinalStates.Contains(neighbour))
                            isFinal = true;
                        neighboursSeenAlnphabet.Add(neighbour);
                    }
                    else if (nfa.Transitions[stateSet[i]].Item2[j] == "_" &&
                        !stateSet.Contains(neighbour))
                        stateSet.Add(neighbour);
                }
            }
            for (int i = 0; i < neighboursSeenAlnphabet.Count; i++)
            {
                for (int j = 0; j < nfa.Transitions[neighboursSeenAlnphabet[i]].Item1.Count; j++)
                {
                    long neighbour = nfa.Transitions[neighboursSeenAlnphabet[i]].Item1[j];
                    if (nfa.Transitions[neighboursSeenAlnphabet[i]].Item2[j] == "_" &&
                        !neighbours.Contains(neighbour))
                    {
                        neighbours.Add(neighbour);
                        if (nfa.FinalStates.Contains(neighbour))
                            isFinal = true;
                        neighboursSeenAlnphabet.Add(neighbour);
                    }
                }
            }
            return neighbours;
        }

        private int GetStateSetIndex(List<List<long>> stateSets, List<long> stateSet)
        {
            for (int i = 0; i < stateSets.Count; i++)
                if (stateSets[i].SequenceEqual(stateSet))
                    return i;
            return -1;
        }

        public override string ToString()
        {
            List<char> result = new List<char>();
            //State count.
            result.AddRange(StateCount.ToString().ToCharArray());
            result.Add(';');

            //Alphabets.
            foreach (string alphabet in Alphabet)
            {
                result.AddRange(alphabet.ToCharArray());
                result.Add(',');
            }
            result.RemoveAt(result.Count - 1);
            result.Add(';');

            //Transitions.
            for (int i = 0; i < Transitions.Count; i++)
            {
                if (i == InitialState)
                    result.AddRange("->");
                for (int alphabetIndex = 0; alphabetIndex < Alphabet.Length; alphabetIndex++)
                {
                    if (FinalStates.Contains(i))
                        result.Add('*');
                    if (Minimized)
                        result.Add('g');
                    else
                        result.Add('q');
                    result.AddRange(i.ToString().ToCharArray());
                    result.Add(',');
                    result.AddRange(Alphabet[alphabetIndex]);
                    result.Add(',');
                    long destination = Transitions[i].Item1[alphabetIndex];
                    if (FinalStates.Contains(destination))
                        result.Add('*');
                    if (Minimized)
                        result.Add('g');
                    else
                        result.Add('q');
                    result.AddRange(destination.ToString().ToCharArray());
                    result.Add(';');
                }
            }
            return new string(result.ToArray());
        }

        public void ToTxtFile(string txtFilePath)
        {
            StreamWriter writer = new StreamWriter(txtFilePath);

            foreach (string str in this.ToString().Split(';'))
                writer.WriteLine(str);
            writer.Close();
        }

        public static DFA Minimizer(DFA dfa)
        {
            //Explore Graph to find reachable states.
            bool[] marked = new bool[(int)dfa.StateCount];
            long[] parent = new long[(int)dfa.StateCount];
            Queue<long> queue = new Queue<long>();

            queue.Enqueue(dfa.InitialState);
            marked[dfa.InitialState] = true;
            long currentNode;
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                foreach (long neighbour in dfa.Transitions[(int)currentNode].Item1)
                {
                    if (!marked[neighbour])
                    {
                        parent[neighbour] = currentNode;
                        marked[neighbour] = true;
                        queue.Enqueue(neighbour);
                    }
                }
            }

            //Divide recheable states to final and nonfinals.
            int[] setNumber = new int[(int)dfa.StateCount];
            List<List<long>> stateSets = new List<List<long>>() { new List<long>(), new List<long>() };
            for (long state = 0; state < dfa.StateCount; state++)
            {
                if (marked[state])
                    if (dfa.FinalStates.Contains(state))
                    {
                        stateSets[1].Add(state);
                        setNumber[(int)state] = 1;
                    }
                    else
                    {
                        stateSets[0].Add(state);
                        setNumber[(int)state] = 0;
                    }
            }

            //Find equivalent states.
            int previousSetCount;
            List<long>[,] stateDestinations;
            do
            {
                previousSetCount = stateSets.Count;
                for (int alphabetIndex = 0; alphabetIndex < dfa.Alphabet.Length; alphabetIndex++)
                {
                    stateDestinations = new List<long>[stateSets.Count, stateSets.Count];
                    for (int row = 0; row < stateSets.Count; row++)
                        foreach (long state in stateSets[row])
                        {
                            int column = setNumber[dfa.Transitions[(int)state].Item1[alphabetIndex]];
                            if (stateDestinations[row, column] == null)
                                stateDestinations[row, column] = new List<long>();
                            stateDestinations[row, column].Add(state);
                        }

                    stateSets = new List<List<long>>();
                    int stateCount = stateDestinations.GetLength(0);
                    for (int row = 0; row < stateCount; row++)
                        for (int column = 0; column < stateCount; column++)
                            if (stateDestinations[row, column] != null)
                            {
                                foreach (long state in stateDestinations[row, column])
                                    setNumber[state] = stateSets.Count;
                                stateSets.Add(stateDestinations[row, column]);
                            }
                }
            } while (previousSetCount != stateSets.Count);

            //Generate minimized DFA.
            List<Tuple<List<long>, List<string>>> transitions = new List<Tuple<List<long>, List<string>>>(stateSets.Count);
            for (int set = 0; set < stateSets.Count; set++)
            {
                transitions.Add(new Tuple<List<long>, List<string>>(new List<long>(), new List<string>()));
                for (int alphabetIndex = 0; alphabetIndex < dfa.Alphabet.Length; alphabetIndex++)
                {
                    transitions[set].Item1.Add(setNumber[dfa.Transitions[(int)stateSets[set][0]].Item1[alphabetIndex]]);
                    transitions[set].Item2.Add(dfa.Alphabet[alphabetIndex]);
                }
            }
            List<long> finalStates = new List<long>();
            foreach (long finalState in dfa.FinalStates)
            {
                finalStates.Add(setNumber[finalState]);
            }
            return new DFA(transitions, dfa.Alphabet, setNumber[dfa.InitialState], finalStates, true);
        }
    }
}
