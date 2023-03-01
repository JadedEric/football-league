# Football League
A small little C# console application to play around with TDD

## Getting Started

Clone the repo and run `dotnet test` to ensure the basic functionality of the application is in check.

There are 3x tests that runs:

`Can_Accept_User_Input_and_Store`

This `test` currently only asserts manual input and responds with a success if the input can be interpreted into the correct `Game` model list.

`Can_Calculate_League_Outcomes_Per_Match`

This `test` asserts each match is correctly calculated and the correct point is allocated for each **win**, **tie** or **loss**.

`Can_Group_League`
This `test` asserts the final output in the form of highest scoring team at the top, and the least at the bottom.