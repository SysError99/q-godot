extends Node2D


const TARGET = Vector2(512, 300)


var tween = Tween.new()


onready var label := $CanvasLayer/Label as Label


class ScnTestSystem extends Node:
	const TARGET = Vector2(512, 300)


	var parent: KinematicBody2D
	# var shared: Dictionary
	var node: Node


	# func _create() -> void:
	# 	var tween := shared.tween as Tween
	# 	tween.interpolate_property(
	# 		parent, "position",
	# 		parent.position, TARGET,
	# 		100
	# 	)
	# 	tween.start()
	# 	parent.look_at(TARGET)


	func _process(_delta: float) -> void:
		var vel := parent.position.direction_to(TARGET) * 10.0
		parent.move_and_slide(vel)
		parent.look_at(TARGET)


func _ready() -> void:
	add_child(tween)
	rand_seed(814995)


	var current_scene := get_tree().current_scene
	for x in 10000:
		var clone := KinematicBody2D.new()
		var sprite := Sprite.new()
		clone.name = "Icon%d" % x
		sprite.name = "Sprite"
		sprite.texture = preload("res://icon.png")
		clone.position = Vector2(randi() % 1024, randi() % 600)
		clone.add_child(sprite)
		current_scene.add_child(clone)


	Groups.bind_query(
		"",
		["KinematicBody2D", "Sprite"],
		ScnTestSystem,
		{"tween": tween,}
	)


# 	Groups.bind_query(
# 		"",
# 		["KinematicBody2D", "Sprite"],
# 		self,
# 		"_entity_entered"
# 	)


# func _entity_entered(parent: KinematicBody2D, sprite: Sprite) -> void:
# 	tween.interpolate_property(
# 		parent, "position",
# 		parent.position, TARGET,
# 		100
# 	)
# 	tween.start()
# 	parent.look_at(TARGET)


func _process(_delta: float) -> void:
	label.text = "FPS: %f" % Engine.get_frames_per_second()
