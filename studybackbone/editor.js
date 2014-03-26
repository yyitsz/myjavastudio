
var Shape = Backbone.Model.extend({
	defaults: {x:50, y:50, width:150, height:150, color:'black'},
	setTopLeft: function(x, y){
		this.set({x:x, y:y});
	},
	setDim: function(w, h){
		this.set({width:w, height:h});
	},
});

var shape = new Shape();

shape.bind('change', function(){
	$('.shape').css({
			left: shape.get('x'),
			top: shape.get('y'),
			width: shape.get('width'),
			height: shape.get('height'),
			background: shape.get('color')
		})
});

var dragging = false;
$('.shape').mousedown(function (e){
	dragging = true;
	shape.set({color: 'gray'});
});

$('#page').mouseup(function (e) {
	dragging = false;
	shape.set({ color: 'black'});
});
$('#page').mousemove(function (e){
	if(dragging) {
		shape.setTopLeft(e.pageX, e.pageY);
		$('#state').text(e.pageX + " " + e.pageY);
	}
});
/*
shape.bind('change', function() {alert('changed!');});
shape.bind('change:width', function(){ alert('width changed!' + shape.get('width'));});
*/
shape.set({ width: 170 });
shape.setTopLeft(100, 300);
shape.set({ color: 'blue' });

