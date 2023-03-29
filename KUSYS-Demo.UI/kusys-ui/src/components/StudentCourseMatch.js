import React, { Component } from 'react';
import axios from 'axios';
import Select from 'react-select';

export class StudentCourseMatch extends Component {
    state = {
        studentList: [],
        courseList: [],
        selectedCourses: [],
        student: {}
    }

    getCourseList = async () => {
        let response = await axios.get("https://localhost:7212/api/Course/GetAll");
        let newData = response.data.list.map(course => {
            return { label: course.name, value: course.id }
        })
        this.setState({
            ...this.state,
            courseList: newData
        });
    }

    getStudentList = async () => {
        let response = await axios.get("https://localhost:7212/api/Student/GetAll");
        this.setState({
            ...this.state,
            studentList: response.data.studentList
        });
    }

    async componentDidMount() {
        await this.getCourseList();
        await this.getStudentList();
    }

    getMatchedList = async (e) => {
        if (e.target.value !== "-1") {
            let response = await axios.get(`https://localhost:7212/api/StudentCourse/GetListForStudent?id=${e.target.value}`);
            this.setState({
                ...this.state,
                student: this.state.studentList.find(x => x.id === Number(e.target.value)),
                selectedCourses: this.state?.courseList?.filter(x => response.data?.list[0]?.list?.some(y => y === x.label))?.map(course => { return course.value })
            });
        }
    }

    setSelectedCourses = (e) => {
        this.setState({
            ...this.state,
            selectedCourses: e.map(x => x.value)
        })
    }

    saveMathces = async (e) => {
        e.preventDefault();
        const { student, selectedCourses } = this.state;

        let model = {
            selectedCourses,
            studentId: student.id,
            studentName: "",
            courseName: ""
        }

        let response = await axios.put("https://localhost:7212/api/StudentCourse/Create", model);
    }

    render() {
        return (
            <div className='col-md-3 mb-4' style={{ margin: "auto" }}>
                <div className='card'>
                    <div className='card-header'>
                        <h4>Student Course Match Form</h4>
                    </div>
                    <div className='card-body'>
                        <form onSubmit={this.saveMathces}>
                            <div className='form-group'>
                                <label htmlFor='student'>Student</label>
                                <select className='form-control' name="student" onChange={this.getMatchedList}>
                                    <option value="-1"> Seçiniz </option>
                                    {
                                        this.state.studentList.map(student => {
                                            return <option key={student.id} value={student.id}>{student.name} {student.surName}</option>
                                        })
                                    }
                                </select>
                            </div>

                            <div className='form-group'>
                                <label htmlFor='course'>Courses</label>
                                <Select
                                    name='course'
                                    className="form-control"
                                    placeholder="Select Option"
                                    value={this.state.courseList.filter(obj => this.state.selectedCourses.includes(obj.value))}
                                    options={this.state.courseList}
                                    onChange={this.setSelectedCourses}
                                    isMulti
                                    isClearable
                                />
                            </div>
                            <button type='submit' className='btn btn-danger btn-block mt-2'> Save Matches</button>
                        </form>
                    </div>
                </div >
            </div >
        )
    }
}

export default StudentCourseMatch
