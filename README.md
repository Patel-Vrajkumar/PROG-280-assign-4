# Assignment 03 – PROG280 – Recursion and the BackgroundWorker

1. Fibonacci [5 marks]
 - Create a class called Fib280 (this part is done for you)
 - Implement and **iterative** algorithm that returns a ulong
   - Method Name: fib_i
   - Input: int
   - Output: ulong
 - Implement and **recursive** algorithm that returns a ulong
   - Method Name: fib_r
   - Input: int
   - Output: ulong
---
2. Towers of Hanoi [10 marks] - [Click here to play on math is fun!](https://www.mathsisfun.com/games/towerofhanoi.html)
 - Create a class called Hanoi280
   - The class should have three stacks created as public properties, call them:
     - Source
     - Destination
     - Spare
   - Implement an iterative algorithm that properly transfers the disks from Source to Destination
     - Method name: go_i
     - No input is required, but once the method completes each disk that started in the source stack should now be in the same order on the destination stack
   - Implement a recursive algorithm that properly transfers disks from source to destination
     - Method name: go_r
     - No input is required, but once the method completes each disk that started in the source stack should now be in the same order on the destination stack
   - Create a function called print that will take a stack as input, instantiate a temporary stack, and build up the string to be printed by moving all items from the input stack to the temporary stack. When the input stack becomes empty, return the items to the input stack from the temporary stack. 
     - Answer the following questions:
       - Why do we shuffle the items back and forth between these two stacks instead of just saying tempStack = inputStack and then performing our operations?
         Note: If you don’t understand why this won’t work, try coding it.
         - Answer here: 
       - After identifying what the problem is in the previous question, research another way we can overcome this problem.
         - Answer here: 
         
         
![image](https://user-images.githubusercontent.com/6656242/215614065-7b51d513-6c93-46d7-bcc1-e2de23c776b8.png)

---

3. Benchmarking Fibonacci [10 marks]
 - Create a windows forms application to compare the run time of **iterative** versus **recursive** implementations of fibonacci
 - Each algorithm should use a BackgroundWorker class to ensure they have designated computing power
 - The UI should provide a checkbox or separate buttons for each algorithm to determine which background workers will be run, and a textbox to collect the input number for the method calls.
 - Performance should be measured by the input number and the amount of time it takes to complete the operation, and of course which algorithm was used. The amount of time can be measured in milliseconds. These results should be displayed in a ListBox.
   - Note: The largest number that ulong can hold is: 18,446,744,073,709,551,615. This means that the highest number you should use for testing is 93. If you wish to use larger numbers add a reference and using statement to System.Numerics, and use BigInteger and refactor.
---

4. Bonus/Challenge Question [1 mark]
 - Build an AVL tree in C#, this type of tree will automatically balance its nodes
 - Create a search function to find a node in the binary tree from the previous assignment and the AVL tree in part a of this question
 - Build a benchmarking application to compare the time it takes to find a certain record in the binary tree vs the AVL tree
   - Generate a list of numbers from 1 to x thousand, shuffle them into random order
   - Insert each item into each tree
 - Try different parameters and determine the time difference in searching each tree
 
 ---

The assignment should be completed individually, you may use the internet to find examples of other developer’s implementations, but remember to cite the materials you use as reference.

You may help your classmates debug their code, but do not share any code you have implemented.

Unit testing this assignment is optional, your code will be run through unit tests during the marking
process.

Hand the code in as a single zip file, the questions from question 2.d can be included in the readme.md file
