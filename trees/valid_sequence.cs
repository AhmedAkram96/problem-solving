/*
Description

Given the root of a binary tree and an integer targetSum, 
return the number of paths where the sum of the values along the path equals targetSum.

The path does not need to start or end at the root or a leaf, but it must go downwards 
(i.e., traveling only from parent nodes to child nodes).
*/

//             10
//         5       -3
//     3       2        11
// 3      -2        1        2

// leetcode link: https://leetcode.com/problems/path-sum-iii/description/
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
public class Solution {
    int count = 0;
    public void recursion(TreeNode root, int targetSum, Dictionary<int, int> freq, int previousSum){
        if(root == null){
            return;
        }
        // downward logic
        int currentSum = previousSum + root.val;
        int temp = currentSum - targetSum;
        if(freq.ContainsKey(temp)){
            count += freq[temp];
        }
        if(freq.ContainsKey(currentSum)){
            freq[currentSum] += 1;
        }else{
            freq[currentSum] = 1;
        }
        recursion(root.left, targetSum, freq, currentSum);
        recursion(root.right, targetSum, freq, currentSum);
        // upward logic
        freq[currentSum] -= 1;

    }
    public int PathSum(TreeNode root, int targetSum) {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        freq[0] = 1;
        recursion(root, targetSum,freq, 0);
        return count;
    }
}


