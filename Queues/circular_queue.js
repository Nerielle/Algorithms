class CircularQueue {
  constructor(size) {

    this.queue = [];
    this.read = 0;
    this.write = 0;
    this.max = size - 1;


    while (size > 0) {
      this.queue.push(null);
      size--;
    }
  }
  
  isFull(){
      return (this.write === this.queue.length -1 && this.read === 0)
        || (write === read -1);
  }

  print() {
    return this.queue;
  }

  enqueue(item) {
      var insertIndex = this.write;
      this.queue[insertIndex] = item;
  }

  dequeue() {
    var popIndex = this.read;
    var item = this.queue[popIndex];
    this.queue[popIndex] = null;
    return item;
  }
}

var q = new CircularQueue(5);
q.enqueue(1);
q.enqueue(2);
q.enqueue(3);
q.enqueue(4);
q.enqueue(5);
q.enqueue(6);