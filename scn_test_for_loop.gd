extends Node2D


const TARGET = Vector2(512, 300)


var icons := []


onready var label := $CanvasLayer/Label as Label


class Icon extends KinematicBody2D:
	var velocity := Vector2.ZERO


func _ready() -> void:
	rand_seed(814995)
	yield(get_tree(), "idle_frame")


	var current_scene := get_tree().current_scene
	for x in 10000:
		var clone := Icon.new()
		var sprite := Sprite.new()
		clone.name = "Icon%d" % x
		sprite.name = "Sprite"
		sprite.texture = preload("res://icon.png")
		clone.position = Vector2(randi() % 1024, randi() % 600)
		clone.add_child(sprite)
		current_scene.add_child(clone)
		icons.push_back([clone, sprite])


func _process(_delta: float) -> void:
	for icon_ref in icons:
		var parent := icon_ref[0] as Icon
		var sprite := icon_ref[1] as Sprite
		var vel := parent.position.direction_to(TARGET) * 10.0
		parent.move_and_slide(vel)
		parent.look_at(TARGET)
	label.text = "FPS: %f" % Engine.get_frames_per_second()
