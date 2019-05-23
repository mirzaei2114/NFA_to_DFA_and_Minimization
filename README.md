# NFA to DFA and Minimization
Given a NFA, Find its equivalent DFA and minimize it.

You Should Enter Address of a .txt File That Contains A NFA Repersenter In This Format:

- 1 Line for Number of States
- 1 Line for Alphabet
- <B> N Lines for Transitions In the Form of:

    + Sorce State, Alphabet, Destination State
    + "->" Prefix of Initial State (In Start Of The Line)
    + "*" Prefix for Final States
</B>

~~ Then Press "Load NFA" to Parse the Text File and Generate NFA.

~~ Now You Can Press "Generate DFA" to Convert NFA to DFA and Also "Minimize DFA" to Minimize It. Note That Every Output Generte in .txt Files and You Should Enter an Address for Each Output .txt File!


Input .txt File Example:

4

a,b

->q0,a,q1

q0,b,q1

q0,a,q2

q0,b,*q3

q1,a,q1

q1,a,*q3

q2,_,q0

*q3,a,q1

*q3,b,q2


Explanation: 

+ We Have 4 States.
+ Our Alphabet is {a, b}.
+ Transitions Like : With Input Alphabet "a" We Go from State "q0" to "q1".
+ Initial State Is "q0".
+ And "q3" Is Our Only Final State. (It Can Be a Set!)


DFA With Same Power (First Output .txt File):

5

a,b

->q0,a,q1

q0,b,*q2

q1,a,*q3

q1,b,*q2

*q2,a,*q2

*q2,b,q4

*q3,a,*q3

*q3,b,*q3

q4,a,q1

q4,b,*q2

Explanation: 

+ We Have 5 States.
+ Our Alphabet is {a, b}.
+ Transitions Like : With Input Alphabet "a" We Go from State "q0" to "q1".
+ Initial State Is "q0".
+ And "q2" and "q3" Are Final States.


Minimized DFA With Same Power (Second Output .txt File):

4

a,b

->g0,a,g1

g0,b,*g2

g1,a,*g3

g1,b,*g2

*g2,a,*g2

*g2,b,g0

*g3,a,*g3

*g3,b,*g3

Explanation: 

*** With Compare This DFA With Last One, We Can Understand That State "q4" Remove. (Equivalent To "q0") ***
+ We Have 4 States.
+ Our Alphabet is {a, b}.
+ Transitions Like : With Input Alphabet "a" We Go from State "g0" to "g1".
+ Initial State Is "g0".
+ And "g2" and "g3" Are Final States.

*****************************
NOW YOU ARE READY TO JOIN! :)
*****************************
