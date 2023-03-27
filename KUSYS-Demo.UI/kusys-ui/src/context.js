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
        default:
            return state;
    }
}

export class AppProvider extends Component {
    state = {
        students: [
        ],
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