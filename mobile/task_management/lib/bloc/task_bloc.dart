import 'package:bloc_pattern/bloc_pattern.dart';
import 'package:rxdart/rxdart.dart';
import 'package:task_management/model/task_model.dart';
import 'package:task_management/repository/task_repository.dart';

class TaskBloc extends BlocBase {
  final TaskRepository taskRepo;
  TaskBloc(this.taskRepo);

  final BehaviorSubject<List<TaskModel>> _taskController =
      BehaviorSubject.seeded(new List<TaskModel>());

  Sink<List<TaskModel>> get sinkTask => _taskController.sink;
  Observable<List<TaskModel>> get streamTask =>
      _taskController.stream.asyncMap((task) => _requestTasks());

  Future requestExternalTask() async {
    var response = await taskRepo.getTasks();
    _taskController.sink.add(response);
  }

  Future<List<TaskModel>> _requestTasks() async {
    var response = await taskRepo.getTasks();
    return response;
  }

  Future<bool> updateTask(TaskModel task) async {
    var updateSuccess = await taskRepo.updateTask(task);
    if (updateSuccess) requestExternalTask();
    return updateSuccess;
  }

  @override
  void dispose() {
    _taskController.close();
    super.dispose();
  }
}
