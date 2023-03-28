import React, { Component } from 'react'
import Student from './Student';
import AppConsumer from '../context';

export class StudentList extends Component {
    render() {
        return (
            <AppConsumer>
                {
                    value => {
                        const { students } = value;
                        return (
                            <div>
                                <h4 className='d-inline'>Student List</h4>
                                <hr/>
                                {
                                    students.map(student => {
                                        return (
                                            <Student key={student.id} student={student} />
                                        )
                                    })
                                }
                            </div>
                        )
                    }
                }
            </AppConsumer>
        )

    }
}

export default StudentList
