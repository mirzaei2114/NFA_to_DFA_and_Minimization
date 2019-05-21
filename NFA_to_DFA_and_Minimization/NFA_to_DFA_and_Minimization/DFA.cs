using System;
using System.Collections.Generic;
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
    }
}
