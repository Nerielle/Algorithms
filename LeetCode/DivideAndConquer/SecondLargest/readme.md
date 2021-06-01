<h2>Problem</h2>
You are given as input an unsorted <b>array</b> of <em>n</em> distinct numbers, where <b>n</b> is a power of <b>2</b>.

Give an algorithm that identifies the <b>second-largest number</b> in the array, and that uses at most <em>n+log<sub>2</sub> n−2</em> comparisons.

<h2>Implementation</h2> 
We compare elements on odd and even positions and configure a new array consisting of maximum of each pair. We do that recursively untill we find max element. 
It would be <em>n-1</em> comparisons.
We have compaired max element of the array with  <em>log<sub>2</sub> n</em> another elements.

So the entire number of comparisons would be:
<em>n+log<sub>2</sub> n - 2</em>.

