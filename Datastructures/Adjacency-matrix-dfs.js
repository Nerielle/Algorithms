function findNeighbour(row, position, visited) {
    var leftNeighbour = row.indexOf(1, position);
    if (leftNeighbour == -1) return null;
    if (visited[leftNeighbour]) {
        return findNeighbour(row, leftNeighbour + 1, visited);
    }
    else {
        return leftNeighbour;
    }
};


function dfs(graph, root) {
    /*
    var lengths = [];
    for(var i=0; i<graph.length; i++){
      lengths[i] = Infinity;
    }
    */
    var stack = [root];
    var currentId;
    var visited = [];
    while (stack.length != 0) {
        currentId = stack[stack.length - 1];
        var row = graph[currentId];
        visited[currentId] = true;
        // console.log('cid',currentId, row);
        var leftNeighbour = findNeighbour(row, 0, visited);
        if (leftNeighbour !== null) {
            visited[leftNeighbour] = true;
            stack.push(leftNeighbour);
        }
        else {
            visited[currentId] = true;
            // lengths of paths from start node
            /* 
            for(var n=0;n<stack.length;n++){
               lengths[stack[n]]=n;
             }
             */
            stack.pop();
        }
    }
    var reachableVertices = visited.map((x, i) => i).filter(x => x != undefined);
    return reachableVertices;
}
var exDFSGraph = [[0, 1, 0, 0], [1, 0, 0, 0], [0, 0, 0, 1], [0, 0, 1, 0]];
console.log(dfs(exDFSGraph, 0));