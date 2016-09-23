## Instructions

Hi. We like to code, and we want to hire people like us. Please read these instructions carefully and follow them the best you can. If you get stuck email us--there's a ```mailto:``` link at the bottom of these instructions to do that.

1. Fork this repository into your own GitHub space.
2. Solve the problem below, checking in to your fork as you go as if this were a real project you're working on. Note that we're also testing your familiarty with GIT and your workflow. We will look at your commit history closely.
3. Submit a pull request back to this repository with your solution when finished.

## 10 Substrings

A 10-substring of a number is a substring of its digits that sum to 10. For example, the 10-substrings of the number 3523014 are:

**352**3014
3**523**014
3**5230**14
35**23014**

A number is called 10-substring-friendly if every one of its digits belongs to a 10-substring. For example, 3523014 is 10-substring-friendly, but 28546 is not.

Write a performant application that discovers all the 10-substring-friendly numbers between 0 and N, where N is an arbitrary, string based input. Some hints:

- This problem has no data dependencies--so it's possible to parallelize the search.
- Solve the problem naively and optimize from there. Divide and conquer.
- Try to use good, readable style.

Examples:

```
N = "0"
[] // Empty Array

N = "19"
[19]

N = "ACD42"
[] // Empty array

N = 100
[19, 28, 37, 46, 55, 64, 73, 82, 91]
```

### Impressive add-ons:

- Consider threading and parallelization.
- Did you write a quick and dirty solution? Now abstract it a bit more and make it elegant and reusable.
- Do you have enough test coverage? Write some load tests if you've run out of unit test targets.

### Rules of the game:

1. You can use any existing frameworks in the programming language of choice.
2. You may pick which interface you want to use without penalty (web page, CLI, console, etc). Clever interfaces will be looked upon favorably.
3. We expect unit tests in the appropriate framework of your choice. If you're using a more exotic programming language or feature set, please provide instructions on how to run your tests. We will be running them. Writing zero tests is a fairly huge penalty.

Hope you have fun, and please email all questions to: code@imaginexconsulting.com.
