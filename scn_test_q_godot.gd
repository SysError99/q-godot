extends Node2D


const TARGET = Vector2(512, 300)


var tween = Tween.new()


class TestSignalBinding extends Node:
	func _enter_tree() -> void:
		QGodot.signal_connect("test_signal", self, "_test_signal_fired")


	func _test_signal_fired(text: String) -> void:
		print("TestSignalBinding: %s" % text)


# class Movement extends Node:
# 	const TARGET = Vector2(512, 300)
# 	var parent: KinematicBody2D
# 	var sprite: Sprite

# 	func _init(parent, sprite) -> void:
# 		self.parent = parent
# 		self.sprite = sprite

# 	func _process(_delta: float) -> void:
# 		var vel := (parent.position.direction_to(TARGET) * 10.0) as Vector2
# 		parent.move_and_slide(vel)
# 		parent.look_at(TARGET)
# 		sprite.scale *= 1.001


onready var label := $CanvasLayer/Label as Label
onready var query := QGodot.query("KinematicBody2D", ["Sprite"])


func _ready() -> void:
	add_child(tween)
	rand_seed(814995)


	# QGodot.bind_query(
	#	"KinematicBody2D",
	# 	["Sprite"],
	# 	Movement
	# )

	add_child(TestSignalBinding.new())
	QGodot.signal_add("test_signal", 1)
	QGodot.emit_signal("test_signal", "Hello, subscriber!")


	for x in 10000:
		var clone := KinematicBody2D.new()
		var sprite := Sprite.new()
		clone.name = "Icon%d" % x
		sprite.name = "Sprite"
		sprite.texture = preload("res://icon.png")
		clone.position = Vector2(randi() % 1024, randi() % 600)
		clone.add_child(sprite)
		add_child(clone)


	print(query.size())


func _process(_delta: float) -> void:
	label.text = "FPS: %f" % Engine.get_frames_per_second()
	for q in query:
		var entity := q["self"] as KinematicBody2D
		var vel := (entity.position.direction_to(TARGET) * 10.0) as Vector2
		q["Sprite"].scale *= 1.001
		entity.move_and_slide(vel)
		entity.look_at(TARGET)


func _input(event: InputEvent) -> void:
	if event.is_action_pressed("ui_home"):
		QGodot.flush()
		get_tree().change_scene("res://scn_next.tscn")
