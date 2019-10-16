import 'package:bloc_pattern/bloc_pattern.dart';
import 'package:flutter/material.dart';
import 'package:task_management/bloc/task_bloc.dart';
import 'package:task_management/pages/task_list.dart';
import 'package:task_management/repository/request_client.dart';
import 'package:task_management/repository/task_repository.dart';

void main() => runApp(BlocProvider(
      child: TaskManagementApp(),
      dependencies: [
        Dependency((i) => RequestClient()),
        Dependency((i) => TaskRepository(i.get<RequestClient>().requestHttp())),
      ],
      blocs: [Bloc((i) => TaskBloc(i.get<TaskRepository>()))],
    ));

class TaskManagementApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Task Management',
      debugShowCheckedModeBanner: false,
      theme: ThemeData(
        appBarTheme: AppBarTheme(color: Colors.indigo[900], elevation: 12.0),
        primaryColor: Colors.indigo,
      ),
      home: TaskManagement(title: 'Task Management'),
    );
  }
}

class TaskManagement extends StatefulWidget {
  TaskManagement({Key key, this.title}) : super(key: key);
  final String title;

  @override
  _TaskManagementState createState() => _TaskManagementState();
}

class _TaskManagementState extends State<TaskManagement> {
  @override
  Widget build(BuildContext context) {
    var bloc = BlocProvider.getBloc<TaskBloc>();
    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Center(
        child: TaskList(),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          bloc.requestExternalTask();
        },
        tooltip: 'Refresh the list',
        child: Icon(Icons.refresh),
      ),
    );
  }
}
