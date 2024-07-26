import React from 'react';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';

type Post = {
  id: number;
  title: string;
  content: string;
};

type PostListProps = {
  posts: Post[];
};

const PostList: React.FC<PostListProps> = ({ posts }) => {
  return (
    <Box>
      {posts.map((post) => (
        <Paper key={post.id} className='mb-4 p-2'>
          <Typography variant='h6'>{post.title}</Typography>
          <Typography>{post.content}</Typography>
        </Paper>
      ))}
    </Box>
  );
};

export default PostList;
