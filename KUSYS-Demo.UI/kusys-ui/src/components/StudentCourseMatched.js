import React, { Component } from 'react'

export class StudentCourseMatched extends Component {
    render() {
        const { name, courseList } = this.props;

        return (
            <div className='col-md-6 mb-4' style={{ margin: "auto" }}>
                <div className='card'>
                    <div className='card-header justify-content-between'>
                        <h4 className='d-inline'> {name} </h4>
                    </div>

                    <div className='card-body'>
                        {
                            courseList.map(courseName => {
                                return <p className='card-text'>Course Name: {courseName}</p>
                            })
                        }
                    </div>
                </div>
            </div>
        )
    }
}

export default StudentCourseMatched
