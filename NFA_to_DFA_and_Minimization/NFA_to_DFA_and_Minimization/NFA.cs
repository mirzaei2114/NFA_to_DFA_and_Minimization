using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NFA_to_DFA_and_Minimization
{
    class NFA
    {
        Tuple<List<long>, List<string>>[] Graph;
        public long StateCount { get; }
        public string[] Alphabet { get; }
        public long InitialState { get; private set; }
        bool InitialStateSet { get; }
        public List<long> FinalStates { get; }
        static Exception inputIncorrectException = new Exception("Input was not in correct format!");

        public NFA(string NFAPath)
        {
            StreamReader reader = new StreamReader(NFAPath);
            InitialStateSet = false;
            StateCount = long.Parse(reader.ReadLine());
            Graph = new Tuple<List<long>, List<string>>[StateCount];
            Alphabet = reader.ReadLine().Split(',');
            string[] lines = reader.ReadToEnd().Split('\n');
            foreach (string line in lines)
                ParsLine(line);
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
                    throw inputIncorrectException;

                if (!FinalStates.Contains(source))
                    FinalStates.Add(source);
            }
            else if (transition[0][0] == '-' && transition[0][1] == '>')
            {
                source = long.Parse(transition[0].Substring(3));
                if (!InitialStateSet)
                    InitialState = source;
                else if (InitialState != source || source >= StateCount)
                    throw inputIncorrectException;
            }
            else
                source = long.Parse(transition[0].Substring(1));

            if (transition[2][0] == '*')
            {
                destination = long.Parse(transition[2].Substring(2));
                if (destination >= StateCount)
                    throw inputIncorrectException;

                if (!FinalStates.Contains(destination))
                    FinalStates.Add(destination);
            }
            else if (transition[2][0] == '-' && transition[2][1] == '>')
            {
                destination = long.Parse(transition[2].Substring(3));
                if (!InitialStateSet)
                    InitialState = destination;
                else if (InitialState != destination || destination >= StateCount)
                    throw inputIncorrectException;
            }
            else
                destination = long.Parse(transition[2].Substring(1));

            //Check for transition alphabet correctness
            if (transition[1] != "_" && !Alphabet.Contains(transition[1]))
                throw inputIncorrectException;

            Graph[source].Item1.Add(destination);
            Graph[source].Item2.Add(transition[1]);
        }
    }
}
