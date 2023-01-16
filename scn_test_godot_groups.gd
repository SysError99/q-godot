extends Node2D


const TARGET = Vector2(512, 300)


var tween = Tween.new()


onready var label := $CanvasLayer/Label as Label


class MoveTowardsCenterSystem extends Node:
	const TARGET = Vector2(512, 300)


	var parent: KinematicBody2D
	# var shared: Dictionary
	var sprite: Sprite


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


# class ShakeSystem extends Node:
# 	const TARGET = Vector2(512, 300)

# 	var parent: KinematicBody2D
# 	var sprite: Sprite

# 	func _process(_delta: float) -> void:
# 		parent.position += Vector2(randi() % 3 - 1, randi() % 3 - 1)


# class BlinkSystem extends Node:
# 	var fade_in := true
# 	var sprite: Sprite

# 	func _create() -> void:
# 		sprite.modulate.a = 0

# 	func _process(delta: float) -> void:
# 		if fade_in:
# 			sprite.modulate.a += delta
# 			if sprite.modulate.a > 1:
# 				fade_in = false
# 		else:
# 			sprite.modulate.a -= delta
# 			if sprite.modulate.a < 0:
# 				fade_in = true


func _ready() -> void:
	add_child(tween)
	rand_seed(814995)

	Groups.bind_query_to_current_scene(
		["KinematicBody2D", "Sprite"],
		MoveTowardsCenterSystem,
		self
	)
	# Groups.bind_query(
	# 	["KinematicBody2D", "Sprite"],
	# 	ShakeSystem,
	# 	self
	# )
	# Groups.bind_query(
	# 	["KinematicBody2D", "Sprite"],
	# 	BlinkSystem,
	# 	self
	# )

	# var query := Groups.query(["KinematicBody2D", "Sprite"])
	# print(query.size())

	for x in 10000:
		var clone := KinematicBody2D.new()
		var sprite := Sprite.new()
		clone.name = "Icon%d" % x
		sprite.name = "Sprite"
		sprite.texture = preload("res://icon.png")
		clone.position = Vector2(randi() % 1024, randi() % 600)
		clone.add_child(sprite)
		add_child(clone)


func _process(_delta: float) -> void:
	label.text = "FPS: %f" % Engine.get_frames_per_second()


func _input(event: InputEvent) -> void:
	if event.is_action_pressed("ui_home"):
		Groups.change_scene("res://scn_next.tscn")
