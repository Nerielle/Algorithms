//breadth first search traversal method with graph given as adjacency matrix
function bfs(graph, start) {
  
  var nodesLen = {};
  
  for (var i = 0; i < graph.length; i++) {
    nodesLen[i] = Infinity;
  }
  nodesLen[start] = 0; 
  var queue = [start]; 
  var currentId; 
  
  while (queue.length !== 0) {
    currentId = queue.shift();
    let currentRow = graph[currentId]; 
    
    let neighborIdx = []; 
	for(let v = 0; v < currentRow.length;v++){
		if(currentRow[v] == 1){
			neighborIdx.push(v);
		}
	}
	
    console.log(neighborIdx,'for ' + currentId);
    
    for (var n = 0; n < neighborIdx.length; n++) {
	  var neighbor = neighborIdx[n];
      
      if (nodesLen[neighbor] === Infinity) {
        nodesLen[neighbor] = nodesLen[currentId] + 1;
        queue.push(neighbor); 
      }
    }
  }
  //object: vertices with path length from start vertex
  return nodesLen;
}

var exBFSGraph = [
  [0, 1, 0, 0],
  [1, 0, 1, 0],
  [0, 1, 0, 1],
  [0, 0, 1, 0]
];
console.log(bfs(exBFSGraph, 3), 'result for 3');