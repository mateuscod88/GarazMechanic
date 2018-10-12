class GarazMenu : extends React.Component{
    constructor(props){
        super(props);
        this.state = {date = null};
    }
    componentDidMount() {
        fetch('/home/menu')
          .then(response => response.json())
          .then(data => this.setState({ data }));
    }
    render(){
        var state = this.state;
        let commentNodes;
        if (this.state.data !== null) {
             commentNodes = this.state.data.map(comment =>
                (<GarazMenuColumn skey={comment.Id} brand={comment.Brand} model={comment.Model } rows={comment.rows}>
                </GarazMenuColumn>
                 ));
        }
        return(
        <div className="menuList">

        </div>
        )
    }
}
class GarazMenuColumn : extends React.Component{
    render(){
    let menuRows;
    if(this.props.rows !== null){
        this.props.rows.map(comment =>
        (
            <GarazMenuRow name={comment.name} link={comment.link}>

            </GarazMenuRow>
        ))
    }
    return(

    )
    }
}
class GarazMenuRow : extends React.Component{

    render(){

    }
}