import React, { Component } from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';

import { getTaskList } from '../../redux-flow/actions/tasks-action'
import TaskList from '../../components/task-list'

const mapStateToProps = state => ({
    taskList: state.taskList.tasks,
});

const mapDispatchToProps = dispatch => ({
    onGetTasks: () => dispatch(getTaskList()),
});

const updateStatus = (taskObject) => {

    console.log(taskObject);

}



class MainContainer extends Component {
    componentDidMount() {
        this.props.onGetTasks();
    }




    render() {
        return (
            <div>
                {/* <NavBar
                    title="Task Management"
                    image=""
                /> */}
                <div className="row">
                    <div className="col-10 col-sm-4">
                        <TaskList taskList={this.props.taskList}
                            updateStatus={updateStatus} />
                    </div>
                </div>
            </div>
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(MainContainer));