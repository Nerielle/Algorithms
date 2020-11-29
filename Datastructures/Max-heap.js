var MaxHeap = function() {
  this.heap = [null];
  function getParentIndex(i)
  {
	  return Math.floor (i/2);
  }
  this.insert = (ele) => {
    var index = this.heap.length;   
    this.heap.push(ele);
	var parentIndex = getParentIndex(index);
    while (ele > this.heap[parentIndex] && index > 1) {
      this.heap[index] = this.heap[parentIndex];
      this.heap[parentIndex] = ele;
      index = parentIndex;
	  parentIndex = getParentIndex(index);
    }
    
  }
  this.print = () => {
    return this.heap.slice(1);
  };

  this.remove = function(){
    if(this.heap.length<= 1){
      return null;
    }
       
    var ret = this.heap[1];
    var arr = [...this.heap];
    arr[1] = arr[arr.length - 1];
    var i = 1;
    var swap;
    while(i< arr.length && (arr[i]<arr[2*i] || arr[i] < arr[2*i+1])  ){
      swap = arr[i]
      if(arr[2*i] > arr[2*i+1]){
        arr[i] = arr[2*i];
        arr[2*i] = swap;
        i=2*i;
      }else{
        arr[i] = arr[2*i+1];
        arr[2*i+1] = swap;
        i = 2*i +1;
      }
    }
    this.heap = arr;
    
    return ret;
  };
  
};
