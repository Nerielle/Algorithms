/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public  class Solution
    {
        public  int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var lengths = new Dictionary<TreeNode, int> {{root, 1}};
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();

                if (currentNode.left == null && currentNode.right == null)
                {
                    return lengths[currentNode];
                }
                if (currentNode.left != null)
                {
                    ProcessChild(queue, currentNode.left, currentNode, lengths);
                }
                if (currentNode.right != null)
                {
                    ProcessChild(queue, currentNode.right, currentNode, lengths);
                }
            }
            return 0;
        }

        private static void ProcessChild(Queue<TreeNode> queue, TreeNode node, TreeNode currentNode,
            Dictionary<TreeNode, int> lengths)
        {
            queue.Enqueue(node);
            lengths[node] = lengths[currentNode] + 1;
        }
    }