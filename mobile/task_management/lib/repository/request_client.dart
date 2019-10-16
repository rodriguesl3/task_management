import 'package:dio/dio.dart';
import 'package:task_management/shared/constant.dart';

class RequestClient {
  Dio dio = Dio();

  RequestClient() {
    dio.options.baseUrl = ConstantsValues.URL_API;
  }

  Dio requestHttp() => dio;
}
