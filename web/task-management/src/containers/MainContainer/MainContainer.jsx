import React, { Component } from 'react';
import { connect } from 'react-redux';
import { withRouter } from 'react-router-dom';

import { getTaskList } from '../../redux-flow/actions/tasks-action'

const mapStateToProps = state => ({
    taskList: state.taskList.tasks,
});

const mapDispatchToProps = dispatch => ({
    onGetTasks: () => dispatch(getTaskList()),
});

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
                        {
                            this.props.taskList ?
                                this.props.taskList.map(element => {
                                    return (element.name + '<br/>')
                                }) : 'loading'
                        }
                        {/* <TaskList taskList={this.props.taskList} /> */}
                    </div>
                </div>
            </div>
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(withRouter(MainContainer));