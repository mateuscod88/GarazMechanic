const data = [
    {
        id: 1,
        name: "Start",
        rows: [{ id: 1, name: "O nas", link: "www.wp.pl" }, { id: 1, name: "O nas", link: "www.wp.pl" }, { id: 1, name: "O nas", link: "www.wp.pl" }]
    },
    {
        id:2,
        name: "Ustawienia",
        rows: [{id:1, name: "O nas", link: "www.wp.pl" }]
    }
]
class GarazMenu extends React.Component{
    //constructor(props){
    //    super(props);
    //    this.state = {date = null};
    //}
    //componentDidMount() {
    //    fetch('/home/menu')
    //      .then(response => response.json())
    //      .then(data => this.setState({ data }));
    //}
    render(){
        var state = this.state;
        let commentNodes;
        if (data !== null) {
             commentNodes = data.map(comment =>
                 (<GarazMenuColumn key={comment.id} name={comment.name} rows={comment.rows}>
                </GarazMenuColumn>
                 ));
        }
        return(
            <div className="menuList">
                {commentNodes}
            </div>
        )
    }
}
class GarazMenuColumn  extends React.Component{
    render(){
    let menuRows;
    if(this.props.rows !== null){
        menuRows = this.props.rows.map(comment =>
        (
            <GarazMenuRow key={comment.id} name={comment.name} link={comment.link}>

            </GarazMenuRow>
        ))
    }
        return (
            <div className="menuColumn">
                {this.props.name}
                {menuRows}
            </div>
        
    )
    }
}
class GarazMenuRow  extends React.Component{

    render(){
        return (
            
            <a href={this.props.link}><div>
                {this.props.name}
            </div></a>
            );
    }
}
ReactDOM.render(
    <GarazMenu />,
    document.getElementById('content-menu')
    )