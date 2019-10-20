import React, { Component } from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';

import { getTaskList, updateTask } from '../../redux-flow/actions/tasks-action'
import TaskList from '../../components/task-list'

const mapStateToProps = state => ({
    taskList: state.taskList.tasks,
    updated: state.taskList.update,
});

const mapDispatchToProps = dispatch => ({
    onGetTasks: () => dispatch(getTaskList()),
    onUpdateTaks: (taks) => dispatch(updateTask(taks)),
});

class MainContainer extends Component {
    componentDidMount(){
        this.props.onGetTasks();
    }
    componentDidUpdate(){
        this.props.onGetTasks();
    }

    updateStatusHandle = (taskObject) => {
        this.props.onUpdateTaks(taskObject);
        this.componentDidMount();
    }

    render() {
        return (
            <div>
                {
                    this.props.updated ?
                        <div class="alert alert-primary" role="alert">
                            Task udpate successfully!!!
                        </div>
                        : ""

                }
                <div className="row">
                    <div className="col-10 col-sm-4">
                        <TaskList taskList={this.props.taskList}
                            updateStatus={this.updateStatusHandle} />
                    </div>
                </div>
            </div>
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(MainContainer));