function object(o){
	function F(){}
	F.prototype = o;
	return new F();
}

function inheritPrototype(subType, superType){
	var prototype = object(superType.prototype);
	prototype.constructor = subType;
	subType.prototype = prototype;
}
function inspect(o){
	var consoleEl = document.getElementById("console");
	var s = consoleEl.innerHTML;
	s += " -------------------------------------- <br />";
	s += "constructor: " + o.constructor + "<br />";
	for(var prop in o){
		if(prop){
			if(o.hasOwnProperty(prop)){
				s += "self:";
			} else {
				s += "prototype:";
			}
			s += prop + "<br />";
		}
	}
	consoleEl.innerHTML = s;
	
}
function print(){
	var consoleEl = document.getElementById("console");
	var s = consoleEl.innerHTML;
	for(var i = 0; i < arguments.length; i++)
	{
		s += String(arguments[i]) + " ";
	}
	s += "<br />";
	consoleEl.innerHTML = s;
}