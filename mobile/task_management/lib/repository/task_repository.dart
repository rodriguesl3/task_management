import 'package:dio/dio.dart';
import 'package:task_management/model/task_model.dart';

class TaskRepository {
  final Dio requestClient;

  TaskRepository(this.requestClient);

  Future<List<TaskModel>> getTasks() async {
    final path = "/tasks";
    Response response = await requestClient.get(path);
    return (response.data as List)
        .map((task) => TaskModel.fromJson(task))
        .toList();
  }

  Future<TaskModel> getTaskById(int id) async {
    final path = "/tasks/$id";
    Response response = await requestClient.get(path);
    return TaskModel.fromJson(response.data);
  }

  Future<bool> saveTask(TaskModel task) async {
    final path = "/tasks";
    Response response = await requestClient.post(path, data: task);
    return response.statusCode == 200;
  }

  Future<bool> updateTask(TaskModel task) async {
    final path = "/tasks/${task.id}";
    Response response = await requestClient.put(path, data: task);
    return response.statusCode == 200;
  }
}
