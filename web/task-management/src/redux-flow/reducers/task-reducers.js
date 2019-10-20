import { GET_TASKLIST, UPDATE_TASK } from '../../constants/index';

export const taskList = (state, action) => {
    if (!state) {
        state = [];
    }
    switch (action.type) {
        case UPDATE_TASK:
            return {
                ...state,
                update: action.payload
            }
        case GET_TASKLIST:
            return {
                ...state,
                tasks: action.payload
            }
        default:
            return state;
    }
}