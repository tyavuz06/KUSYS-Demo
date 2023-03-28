import React, { Component } from 'react'
import axios from 'axios';
import StudentCourseMatched from './StudentCourseMatched';

export class StudentCourseMatchedList extends Component {
    state = {
        studentCourseList: []
    }

    getList = async () => {
        let response = await axios.get("https://localhost:7212/api/StudentCourse/GetList");
        // dispatch({type: "STUDENT_COURSE_LIST", payload: response.data.list})
        this.setState({
            ...this.state,
            studentCourseList: response.data.list
        })
    }

    async componentDidMount() {
        await this.getList();
    }

    render() {
        return (
            <div>
                <h4 className='col-md-6 mb-4' style={{margin:"auto"}}>Student Course Matched List</h4>
                <hr />
                {                    
                    this.state.studentCourseList.map(studentCourse => {
                        console.log(studentCourse.studentId, studentCourse.studentName)
                        return (
                            <StudentCourseMatched key={studentCourse.studentId} name={studentCourse.studentName} courseList={studentCourse.list} />
                        )
                    })
                }
            </div>
        )
    }
}

export default StudentCourseMatchedList
