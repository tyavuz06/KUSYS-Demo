import React, { Component } from 'react'
import AppConsumer from '../context';
import posed from 'react-pose';
import axios from 'axios';

const Animation = posed.div({
    visible: {
        opacity: 1,
        applyAtStart: {
            display: "block"
        }
    },
    hidden: {
        opacity: 0,
        applyAtEnd: {
            display: "none"
        }
    }
});

export class Student extends Component {
    getDetail = (e) => {
    }

    state = {
        isVisible: false
    }

    onClickEvent = () => {
        this.setState({
            isVisible: !this.state.isVisible
        })
    }

    onDeleteStudent = async (dispatch, e) => {
        const { student } = this.props;
        await axios.delete(`https://localhost:7212/api/Student/Delete?id=${student.id}`)

        dispatch({ type: "DELETE_STUDENT", payload: student.id })
    }

    render() {
        const { student } = this.props;
        const { isVisible } = this.state;
        return (<AppConsumer>
            {
                value => {
                    const { dispatch } = value;
                    return (
                        <div className='col-md-8 mb-4' style={{ marginLeft: '20px' }}>
                            <div className='card' style={isVisible ? { backgroundColor: "#62848d", color: "white" } : null} onClick={this.onClickEvent}>
                                <div className='card-header d-flex justify-content-between'>
                                    <h4 className='d-inline'> {isVisible ? <i className="fa-solid fa-angle-up"></i> : <i className="fa-solid fa-angle-down"></i>} {student.name} {student.surName} </h4>
                                    <i className='far fa-trash-alt' style={{ cursor: "pointer" }} onClick={this.onDeleteStudent.bind(this, dispatch)}></i>
                                </div>
                                <Animation pose={isVisible ? "visible" : "hidden"}>
                                    <div className='card-body'>
                                        <p className='card-text'>Name: {student.name}</p>
                                        <p className='card-text'>SurName: {student.surName}</p>
                                        <p className='card-text'>Birth Date: {student.birthDate}</p>
                                        <p className='card-text'>Identity Number: {student.identityNo}</p>
                                    </div>
                                </Animation>
                            </div>
                        </div>
                    )
                }
            }
        </AppConsumer>
        )
    }
}

export default Student
