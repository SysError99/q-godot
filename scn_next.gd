extends Node2D


# Declare member variables here. Examples:
# var a: int = 2
# var b: String = "text"


class RotateSystem extends Node:
	var parent: KinematicBody2D
	var sprite: Sprite

	func _init(parent, sprite) -> void:
		self.parent = parent
		self.sprite = sprite

	func _process(_delta: float) -> void:
		parent.rotate(_delta * PI)


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	QGodot.bind_query(
		"KinematicBody2D",
		["Sprite"],
		RotateSystem,
		self
	)
	for x in 100:
		var clone := KinematicBody2D.new()
		var sprite := Sprite.new()
		clone.name = "Icon%d" % x
		sprite.name = "Sprite"
		sprite.texture = preload("res://icon.png")
		clone.position = Vector2(randi() % 1024, randi() % 600)
		clone.add_child(sprite)
		add_child(clone)


# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta: float) -> void:
#	pass
