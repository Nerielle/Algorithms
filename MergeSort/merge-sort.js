function mergeSort(array) {
    if (array.length < 2) {
        return array;
    }
    var middle = Math.floor(array.length / 2);
    var firstArray = mergeSort(array.slice(0, middle));
    var secondArray = mergeSort(array.slice(middle));
    return merge(firstArray, secondArray, array);
}

function merge(left, right, array) {
    let l = 0;
    let r = 0;
    for (let i = 0; i < array.length; i++) {
        if (l < left.length && r < r.length) {
            if (left[l] < right[r]) {
                array[i] = left[l];
                l++;
                continue;
            }
            array[i] = right[r]
            r++;
            continue;
        }
        if (l < left.length) {
            array[i] = left[l];
            l++;
        }
        if (r < right.length) {
            array[i] = right[r];
            r++;
        }
    }
    console.log(left, right, array);
    return array;
}
mergeSort([1, 4, 2, 8, 345, 123, 43, 32, 5643, 63, 123, 43, 2, 55, 1, 234, 92]);