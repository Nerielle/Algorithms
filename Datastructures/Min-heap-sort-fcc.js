const MinHeap = function() {
	this.nodes = [];
	this.getLeftIndex = (index) => 2 * index + 1;
	this.getRightIndex = (index) => 2 * index + 2;
	this.getParentIndex = (index) => {
		if (index === 0) return undefined;
		return Math.floor((index - 1) / 2);
	}
	this.insert = function(value) {
		this.nodes.push(value);
		let currentIndex = this.nodes.length - 1;
		let parentIndex = this.getParentIndex(currentIndex);
		while (parentIndex >= 0 && value < this.nodes[parentIndex]) {
			// Swap the parent for the child.
			this.swap(currentIndex, parentIndex);
			currentIndex = parentIndex;
			parentIndex = this.getParentIndex(currentIndex);
		}
	}
	this.remove = function() {
		if (this.nodes.length) {
			// Swap the first with the last node.
			this.swap(0, this.nodes.length - 1);		
			// Pop the min value.
			let minValue = this.nodes.pop();
			// Resort the array.
			this.siftDown(0);
			return minValue;
		}
	}
	this.siftDown = function(index) {
		let smallestIndex = index;
		let left = this.getLeftIndex(index);
		let right = this.getRightIndex(index);
		let size = this.nodes.length;
		if (left < size && this.nodes[left] < this.nodes[smallestIndex]) {
			smallestIndex = left;
		}
		if (right < size && this.nodes[right] < this.nodes[smallestIndex]) {
			smallestIndex = right;
		}
		if (index !== smallestIndex) {
			this.swap(smallestIndex, index);
			this.siftDown(smallestIndex);
		}
	}

	this.print = function() {
		return this.nodes;
	}
	this.swap = function(indexA, indexB) {
		let temp = this.nodes[indexA];
		this.nodes[indexA] = this.nodes[indexB];
		this.nodes[indexB] = temp;
	}
	this.sort = function() {
		let sorted = [];
		let heap = [...this.nodes];
		while (this.nodes.length) {
			sorted.push(this.remove());
		}
		this.nodes = heap;
		return sorted;
	}
};
