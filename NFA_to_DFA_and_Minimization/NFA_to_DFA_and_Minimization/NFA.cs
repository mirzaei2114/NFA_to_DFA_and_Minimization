using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NFA_to_DFA_and_Minimization
{
    class NFA
    {
        public Tuple<List<long>, List<string>>[] Transitions { get; }
        public long StateCount { get; }
        public string[] Alphabet { get; }
        public long InitialState { get; private set; }
        bool InitialStateSet { get; }
        public List<long> FinalStates { get; }
        static readonly Exception InputIncorrectException = new Exception("Input Was Not In Correct Format!");

        public NFA(string NFAPath)
        {
            StreamReader reader = new StreamReader(NFAPath);
            InitialStateSet = false;
            try
            {
                StateCount = long.Parse(reader.ReadLine());
                Alphabet = reader.ReadLine().Split(',');
            }
            catch
            {
                throw InputIncorrectException;
            }
            Transitions = new Tuple<List<long>, List<string>>[StateCount];
            for (int i = 0; i < StateCount; i++)
                Transitions[i] = new Tuple<List<long>, List<string>>(new List<long>(), new List<string>());
            FinalStates = new List<long>();
            string[] lines = reader.ReadToEnd().Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines)
                ParsLine(line);
            reader.Close();
        }

        private void ParsLine(string line)
        {
            string[] transition = line.Split(',');
            long source;
            long destination;

            //Recognize initial and final state and set source and destination.
            if (transition[0][0] == '*')
            {
                source = long.Parse(transition[0].Substring(2));
                if (source >= StateCount)
                    throw InputIncorrectException;

                if (!FinalStates.Contains(source))
                    FinalStates.Add(source);
            }
            else if (transition[0][0] == '-' && transition[0][1] == '>')
            {
                source = long.Parse(transition[0].Substring(3));
                if (!InitialStateSet)
                    InitialState = source;
                else if (InitialState != source || source >= StateCount)
                    throw InputIncorrectException;
            }
            else
                source = long.Parse(transition[0].Substring(1));

            if (transition[2][0] == '*')
            {
                destination = long.Parse(transition[2].Substring(2));
                if (destination >= StateCount)
                    throw InputIncorrectException;

                if (!FinalStates.Contains(destination))
                    FinalStates.Add(destination);
            }
            else if (transition[2][0] == '-' && transition[2][1] == '>')
            {
                destination = long.Parse(transition[2].Substring(3));
                if (!InitialStateSet)
                    InitialState = destination;
                else if (InitialState != destination || destination >= StateCount)
                    throw InputIncorrectException;
            }
            else
                destination = long.Parse(transition[2].Substring(1));

            //Check for transition alphabet correctness
            if (transition[1] != "_" && !Alphabet.Contains(transition[1]))
                throw InputIncorrectException;

            //Add transition
            Transitions[source].Item1.Add(destination);
            Transitions[source].Item2.Add(transition[1]);
        }
    }
}
