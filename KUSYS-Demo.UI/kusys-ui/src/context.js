import React, { Component } from 'react'
import axios from "axios";

const appContext = React.createContext();
const reducer = (state, action) => {
    switch (action.type) {
        case "DELETE_STUDENT":
            return {
                ...state,
                students: state.students.filter(student => student.id !== action.payload)
            }
        case "CREATE_STUDENT":
            return {
                students: [...state.students, action.payload]
            }
        case "GET_STUDENT":
            return {
                ...state,
                // id: student.id,
                // name: student.name,
                // surName: student.surName,
                // identityNo: student.identityNo,
                // birthDate: student.birthDate
            }
        case "EDIT_STUDENT":
            let student = action.payload.data.student;
            return {
                ...state,
                id: student.id,
                name: student.name,
                surName: student.surName,
                identityNo: student.identityNo,
                birthDate: student.birthDate,
                visible: true,
                isEdit: true
            }
        case "EDITED_STUDENT":
            let data = state.students.filter(x => x.id !== action.payload.id);
            debugger;
            return {
                ...state,
                students: [...data, action.payload],
                isEdit: false,
                visible: !state.visible,
            }
        case "CHANGE_VISIBILITY":
            return {
                ...state,
                visible: !state.visible,
                isEdit: false
            }
        case "SET_PROPS":
            let keys = Object.keys(action.payload);
            return {
                ...state,
                [keys[0]]: action.payload[keys]
            }
        case "STUDENT_COURSE_LIST":
            return {
                ...state,
                studentCourseList: action.payload
            }
        default:
            return state;
    }
}

export class AppProvider extends Component {
    state = {
        students: [
        ],
        studentCourseList:[
        ],
        visible: false,
        isVisible: false,
        id: "",
        name: "",
        surName: "",
        identityNo: "",
        birthDate: "",
        isEdit: false,
        dispatch: action => {
            this.setState(state => reducer(state, action))
        }
    }

    componentDidMount = async () => {
        let response = await axios.get("https://localhost:7212/api/Student/GetAll");

        this.setState({
            students: response.data.studentList
        });
    }

    render() {
        return (
            <appContext.Provider value={this.state}>
                {this.props.children}
            </appContext.Provider>
        )
    }
}

const AppConsumer = appContext.Consumer;

export default AppConsumer;