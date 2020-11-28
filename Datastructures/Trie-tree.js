var displayTree = tree => console.log(JSON.stringify(tree, null, 2));
var Node = function() {
  this.keys = new Map();
  this.end = false;
  this.setEnd = function() {
    this.end = true;
  };
  this.isEnd = function() {
    return this.end;
  };
};
var Trie = function() {

  this.root = new Node();
    
  this.add = function(word){
   
    var current = this.root;
   
    for(let ch = 0; ch < word.length; ch++){
      var node; 
      var char = word[ch];
      if(current.keys.has(char)){
        node = current.keys.get(char);
       
      }else{
        node = new Node();
        
        current.keys.set(char, node);
       
      }
      current = node;
    }
    current.setEnd();
    
  };
  this.isWord = function(str){
   console.log('s isw', str)
   if(!str || str == '' ){
     return false;
   } 

   var current = this.root;
   for (var i = 0; i < str.length; i++) {
     var char = str[i];
     var node = current.keys.get(char);
     
     if(!node){
       console.log('char not found ', str, false)
       return false;
     }
     current = node;
   }
   console.log('return ',str , current.isEnd())
   return current.isEnd();
  };

 this.print  = function(){
  
   var result = [];
 
   addwordToResult(this.root, '',result);
  
 return result;
 }
 function addwordToResult(node, word ='', result){
   //console.log("current", node.keys, word);

   for(const [key,subnode] of node.keys){
      
      //console.log('sub', subnode, key);
      if(subnode.isEnd()){
       // console.log('end ', word);
        result.push(word + key);        
       
      }
     // console.log(2, word)
      addwordToResult(subnode, word + key, result);      
    
   }
 }
};


 var tree = new Trie();
 tree.add('son');
 tree.add('ink');
 tree.add('jump');
 tree.add('crack');
 tree.add('idle');
 
 tree.add('sun');
 tree.print();
 tree.isWord('su');
 tree.isWord('sunk');
 tree.isWord('son');