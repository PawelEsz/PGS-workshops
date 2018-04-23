import React from 'react';
import List from './List';
import axios from 'axios';
import { BASE_URL } from '../constants';
import './Board.css';
import { withRouter } from 'react-router-dom'

class Board extends React.Component {

    constructor(){
        super();
        this.state = {
            boardName: '',
            boardId: 0,
            boardData: [],
            listName: ''
        };
    }

    componentDidMount(){
        axios.get(BASE_URL + '/board').then((response) => {
            console.log(response);
            this.setState({
                boardData: response.data.lists,
                boardName: response.data.name,
                boardId: response.data.id
            });
        }).catch(() => {
            this.props.history.push('/new');
        });
    }

    onClickList = (e) => {
        //this.setState({ listName: e.target.value});
        //console.log(this.state.listName)
        axios.post(BASE_URL + '/List', {boardId: this.state.boardId, name: this.state.listName})
        .then(response => 
            {
            console.log(response);
            this.setState(prevState =>{ 
                return {
                    boardData: [...prevState.boardData, response.data],
                    listName: ''
                }
            });
        })
    }

    onChangeListName = (e) => {
        this.setState({ listName: e.target.value})
    }

    deleteListFromView = (index, e) => {
        const boardData = Object.assign([], this.state.boardData);
        boardData.splice(index,1);
        this.setState({boardData: boardData})
    }

    renderLists = () => {
        //map zwraca tablice, a foreach nic
       return this.state.boardData.map((list, index) => (
       <List key={list.id} deleteEvent={this.deleteListFromView.bind(this, index)} boardId={this.state.boardId} listId={list.id} listName={list.name} cards={list.cards}/>
        ));
    }

    render(){
        return(
            <div>
                <h3>{this.state.boardName}</h3>
                <div>
                    <input type="text" value={this.state.listName} onChange={this.onChangeListName }/>
                    <button className="btn btn-info" onClick={this.onClickList} disabled={!this.state.listName}>Add new list</button>
                </div>

                <div className="container-fluid">
                    <div className="row flex-row flex-nowrap">
                        {this.renderLists()}
                    </div>
                </div>
            </div>
        )
    }

}

export default withRouter(Board);