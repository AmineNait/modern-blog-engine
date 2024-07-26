import React from 'react';
import PostList from '../../components/PostList';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';

const posts = [
  {
    id: 1,
    title: 'First Post',
    content: 'This is the content of the first post.',
  },
  {
    id: 2,
    title: 'Second Post',
    content: 'This is the content of the second post.',
  },
];

const PostsPage: React.FC = () => {
  return (
    <Container>
      <Typography variant='h4' gutterBottom>
        Posts
      </Typography>
      <PostList posts={posts} />
    </Container>
  );
};

export default PostsPage;
