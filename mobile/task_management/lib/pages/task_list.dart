import 'package:bloc_pattern/bloc_pattern.dart';
import 'package:flutter/material.dart';
import 'package:task_management/bloc/task_bloc.dart';
import 'package:task_management/model/task_model.dart';

class TaskList extends StatelessWidget {
  const TaskList({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var bloc = BlocProvider.getBloc<TaskBloc>();

    return StreamBuilder<List<TaskModel>>(
        stream: bloc.streamTask,
        builder: (context, snapshot) {
          if (!snapshot.hasData) {
            return Text('there is no information');
          } else if (snapshot.hasError) {
            return Text('there is an error to get tasks');
          }

          var taskList = snapshot.data;

          return ListView.separated(
            separatorBuilder: (context, index) => Divider(
              color: Colors.black,
            ),
            itemCount: taskList.length,
            itemBuilder: (context, index) => ListTile(
              title: Text(taskList[index].name),
              subtitle: Text('Created at: ${taskList[index].timeStamp}'),
              trailing: Checkbox(
                value: taskList[index].status == 0 ? false : true,
                activeColor: Colors.indigo,
                onChanged: (bool value) {
                  print("${taskList[index].name} -> status: $value");
                  var task = taskList[index];
                  task.status = value ? 1 : 0;
                  bloc.updateTask(task).then((response) {
                    final responseMessage =
                        response ? "Update successfully" : "Proble to udpate";

                    final snackBar = SnackBar(
                      content: Text(responseMessage),
                      duration: Duration(seconds: 2),
                    );
                    Scaffold.of(context).showSnackBar(snackBar);
                  });
                },
              ),
              onTap: () {
                print(taskList[index]);
                // Navigator.push(context,
                // MaterialPageRoute(builder: (context)=>
                // TaskDetail(taskList[index])));
              },
            ),
          );
        });
  }
}