import { GET_TASKLIST } from '../../constants/index';

export const taskList = (state, action) => {
    if (!state) {
        state = [];
    }
    switch (action.type) {
        case GET_TASKLIST:
            return {
                ...state,
                tasks: action.payload
            }
        default:
            return state;
    }
}