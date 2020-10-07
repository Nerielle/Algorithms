/// Priority Queue where lower priorities has precedence
/// we have a priority queue with three items:

///[['kitten', 2], ['dog', 2], ['rabbit', 2]]

/// Here the second value (an integer) represents item priority. 
///If we enqueue ['human', 1] with a priority of 1  it would then be the first item to be dequeued. 
/// I'm using min-heap (Binary Heap)
function PriorityQueue () {
  this.collection = [];
  this.items = {};
  this.printCollection = function() {
    console.log(this.collection);
  };
  
  this.isEmpty = function(){
    return this.collection.length === 0;
  };
 
  this.size = function(){
    return this.collection.length;
  };
 
  this.front = function front(){
    return this.items[collection[0]][0];
  };
 
  this.enqueue = function(item){	  
  	var length = this.collection.push(item[1]);
	if(this.items.hasOwnProperty(item[1])){
		this.items[item[1]].push(item[0]);
	}else
	{
		this.items[item[1]] = [item[0]];
	}
    this.percolate(this.collection, length -1, length); 
};

this.heapify = function heapify(arr, i, size){
	var smallest = i;
	var left  = 2*i + 1;
	var right = 2*i +2;
	if(left < size && arr[smallest]>= arr[left]){
		smallest = left;
	}
	if(right< size && arr[smallest] >= arr[right]){
		smallest = right;
	}
	
	if(smallest != i){
		var swap = arr[i];
		arr[i] = arr[smallest];
		arr[smallest] = swap;
		heapify(arr,smallest, size);
	}
	
};
this.percolate= function perlocate(arr, index, length){
    
	var priority = arr[index];
	var parent = Math.floor((index-1)/2);
  
	if(parent>=0 && priority < arr[parent]){
		var swap = arr[index];
		arr[index] = arr[parent];
		arr[parent] = swap;
	this.percolate(arr, parent, length);
  }
  
};
 
  this.dequeue = function(){
    var lastIndex = this.collection.length - 1;	
	var itemPriority = this.collection[0];
	this.collection[0] = this.collection[lastIndex];
	
	this.collection.pop();
	this.heapify(this.collection,0, this.collection.length);

	return this.items[itemPriority].shift();
  };
 
}
 
var q = new PriorityQueue();
q.enqueue(['rabbit',2]);
q.enqueue(['dog',2]);
q.enqueue(['goose',3]);
q.enqueue(['parrot',1]);
q.enqueue(['horse',7]);
q.enqueue(['cow',5]);
q.printCollection();
console.log('dequeue', q.dequeue());
q.printCollection();
console.log('dequeue', q.dequeue());
console.log('dequeue', q.dequeue());
console.log('dequeue', q.dequeue());
console.log('dequeue', q.dequeue());
q.enqueue(['parrot',1]);
q.enqueue(['horse',7]);
q.enqueue(['cow',5]);
console.log('dequeue', q.dequeue());
q.printCollection();
console.log(q.size());
 
 

