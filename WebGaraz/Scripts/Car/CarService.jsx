const dataCar = [
  { Id: 1, Brand: "Vw", Model: "Passat" },
  { Id: 2, Brand: "Audi", Model: "A6" },
  { Id: 3, Brand: "Skoda", Model: "Octavia" }
];
class CarList extends React.Component{
    constructor(props) {
        super(props);
        this.state = { data: null };
    }

    componentDidMount() {
        fetch('/home/allcars')
          .then(response => response.json())
          .then(data => this.setState({ data }));
    }
    render() {
        var state = this.state;
        let commentNodes;
        if (this.state.data !== null) {
             commentNodes = this.state.data.map(comment =>
                (<Car skey={comment.Id} brand={comment.Brand} model={comment.Model }>
                    {comment.Id}
                </Car>
                 ));
        }
        
      return (
      <div className="commentList">
          {commentNodes}
      </div>
      );
  }
}
class Car extends React.Component{
    rawMarkup() {
    const md = new Remarkable();
    const rawMarkup = md.render(this.props.children.toString());
    return { __html: rawMarkup };
  }
  render() {
    return (
      <div className="comment">
        <h2 className="commentAuthor">
            {this.props.brand} and {this.props.model}
        </h2>
        <span dangerouslySetInnerHTML={this.rawMarkup()} />
      </div>
    );
  }
}
ReactDOM.render(
  <CarList url="/home/allcars" />,
  document.getElementById('content-car')
);