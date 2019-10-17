import Axios from 'axios';
import { GET_TASKLIST } from '../../constants';


const dispatchTaskList = (response, dispatch) => {
    if (response.status === 200) {
        dispatch({
            type: GET_TASKLIST,
            payload: response.data,
        })
    }
}

export const getTaskList = () => (dispatch) => {
    let url = 'http://localhost:32780/api/tasks'
    return Axios.get(url)
        .then(response => dispatchTaskList(response, dispatch));
}

