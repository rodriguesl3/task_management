import Axios from 'axios';
import { GET_TASKLIST, UPDATE_TASK } from '../../constants';


const dispatchTaskList = (response, dispatch) => {
    if (response.status === 200) {
        dispatch({
            type: GET_TASKLIST,
            payload: response.data
        })
    }
}

const dispatchUpdateTask = (response, dispatch) => {
    if (response.status === 200) {
        dispatch({
            type: UPDATE_TASK,
            payload: true
        })
    }
}

export const getTaskList = () => (dispatch) => {
    let url = 'http://localhost:32780/api/tasks'
    return Axios.get(url)
        .then(response => dispatchTaskList(response, dispatch));
}

export const updateTask = (task) => dispatch => {
    var url = `http://localhost:32780/api/tasks/${task.id}`;
    Axios.put(url, task).then((response) => dispatchUpdateTask(response, dispatch));
}

