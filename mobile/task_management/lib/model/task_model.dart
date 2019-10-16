import 'dart:convert';

List<TaskModel> taskModelFromJson(String str) => List<TaskModel>.from(json.decode(str).map((x) => TaskModel.fromJson(x)));

String taskModelToJson(List<TaskModel> data) => json.encode(List<dynamic>.from(data.map((x) => x.toJson())));

class TaskModel {
    int id;
    String name;
    String timeStamp;
    int status;

    TaskModel({
        this.id,
        this.name,
        this.timeStamp,
        this.status,
    });

    factory TaskModel.fromJson(Map<String, dynamic> json) => TaskModel(
        id: json["id"],
        name: json["name"],
        timeStamp: json["timeStamp"],
        status: json["status"],
    );

    Map<String, dynamic> toJson() => {
        "id": id,
        "name": name,
        "timeStamp": timeStamp,
        "status": status,
    };
}