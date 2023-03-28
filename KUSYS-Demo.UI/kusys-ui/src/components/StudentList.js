import React, { Component } from 'react'
import Student from './Student';
import AddStudent from './AddStudent';
import AppConsumer from '../context';

export class StudentList extends Component {
    render() {
        return (
           <div>
             <AddStudent />
             <AppConsumer>
                {
                    value => {
                        const { students } = value;
                        return (
                            <div>
                                <h4 className='col-md-12 mb-4 d-inline'>Student List</h4>
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
           </div>
           
        )

    }
}

export default StudentList
