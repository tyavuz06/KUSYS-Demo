import React, { Component } from 'react'
import AppConsumer from '../context';
// import posed from 'react-pose';
import axios from 'axios';

// const Animation = posed.div({
//     visible: {
//         opacity: 1,
//         applyAtStart: {
//             display: "block"
//         }
//     },
//     hidden: {
//         opacity: 0,
//         applyAtEnd: {
//             display: "none"
//         }
//     }
// });

export class Student extends Component {
    state = {
        isVisible: false,
        student: {}
    }

    onClickEvent = async () => {
        const { student } = this.props;
        let response = await axios.get(`https://localhost:7212/api/Student/GetDetail?id=${student.id}`)
        this.setState({
            isVisible: !this.state.isVisible,
            student: response.data.student
        });
    }

    onDeleteStudent = async (dispatch, id, e) => {
        await axios.delete(`https://localhost:7212/api/Student/Delete?id=${id}`)

        dispatch({ type: "DELETE_STUDENT", payload: id })
    }

    onEditStudent = async (dispatch, id, e) => {
        let response = await axios.get(`https://localhost:7212/api/Student/GetDetail?id=${id}`)

        dispatch({ type: "EDIT_STUDENT", payload: response })
    }

    render() {
        const { isVisible } = this.state;
        const { student } = this.props;
        return (<AppConsumer>
            {
                value => {
                    const { dispatch } = value;
                    return (
                        <div className='col-md-3 mb-4' style={{ margin: "auto"}}>
                            <div className='card' style={isVisible ? { backgroundColor: "#62848d", color: "white" } : null} onClick={this.onClickEvent}>
                                <div className='card-header justify-content-between'>
                                    {isVisible ? <i className="fa-solid fa-angle-up mt-2" style={{ float: "left" }}></i> : <i className="fa-solid fa-angle-down mt-2" style={{ float: "left" }}></i>}
                                    <h4 className='d-inline'>  {student.name} {student.surName} </h4>
                                    <i className="fa-solid fa-user-pen mt-2" style={{ cursor: "pointer", float: "right", marginLeft: "5px" }} onClick={this.onEditStudent.bind(this, dispatch, student.id)}></i>
                                    <i className='far fa-trash-alt mt-2' style={{ cursor: "pointer", float: "right", marginLeft: "5px" }} onClick={this.onDeleteStudent.bind(this, dispatch, student.id)}></i>
                                </div>
                                {/* <Animation pose={isVisible ? "visible" : "hidden"}> */}
                                <div className='card-body' style={isVisible ? null : { display: "none" }}>
                                    <p className='card-text'>Name: {this.state.student.name}</p>
                                    <p className='card-text'>SurName: {this.state.student.surName}</p>
                                    <p className='card-text'>Birth Date: {this.state.student.birthDate}</p>
                                    <p className='card-text'>Identity Number: {this.state.student.identityNo}</p>
                                </div>
                                {/* </Animation> */}
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
