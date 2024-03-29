﻿const data = [
  { Id: 1, Author: "Daniel Lo Nigrooo", Text: "Hello ReactJS.NET World!" },
  { Id: 2, Author: "Pete Hunt", Text: "This is one comment" },
  { Id: 3, Author: "Jordan Walke", Text: "This is *another* comment" }
];
class CommentList extends React.Component {
  render() {
      const commentNodes = this.props.data.map(comment =>
          (<Comment author={comment.Author} skey={comment.Id}>
            {comment.Id}
           </Comment>
           ));
      return (
      <div className="commentList">
          {commentNodes}
      </div>
      )
  }
}

class CommentForm extends React.Component {
  render() {
    return (
      <div className="commentForm">
          Hello, world! I am a CommentForm.
      </div>
    );
  }
}
class CommentBox extends React.Component {
  render() {
    return (
      <div className="commentBox">
        <h1>Comments</h1>
        <CommentList data={this.props.data} />
        <CommentForm />
      </div>
    );
  }
}
class Comment extends React.Component {
  rawMarkup() {
    const md = new Remarkable();
    const rawMarkup = md.render(this.props.children.toString());
    return { __html: rawMarkup };
  }
  render() {
    return (
      <div className="comment">
        <h2 className="commentAuthor">{this.props.author} and {this.props.skey}
        </h2>
        <span dangerouslySetInnerHTML={this.rawMarkup()} />
      </div>
    );
  }
}
ReactDOM.render(
  <CommentBox data={data} />,
  document.getElementById('content')
);