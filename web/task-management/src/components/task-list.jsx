import React from 'react';
import CustomCheckBox from './custom-checkbox/custom-checkbox';





const TaskList = (props) => {
    const { taskList, updateStatus } = props;
    const statusChages = (id, isComplete) => {
        let updateTask = taskList.filter(elm => elm.id == id)[0];
        updateTask.status = isComplete ? 1 : 0;
        updateStatus(updateTask);

    }


    return (
        <div className="container">
            <h3 className="title">What you have to do.</h3>
            <div className="row">
                <div className="card">
                    <div class="card-header">Featured</div>
                    <ul className="list-group list-group-flush">
                        {
                            taskList ?
                                taskList.map(element => {
                                    return (
                                        <li className="list-group-item">
                                            <CustomCheckBox isChecked={element.status}
                                                description={element.name}
                                                keyCode={element.id}
                                                changeStatus={statusChages}
                                            />
                                        </li>)
                                }) : 'loading'
                        }
                    </ul>
                </div>
            </div>
            <div className="row">


            </div>
        </div >
    )
}

export default TaskList;