import React from 'react';
import Typography from '@mui/material/Typography';
import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';

type Category = {
  id: number;
  name: string;
};

type CategoryListProps = {
  categories: Category[];
};

const CategoryList: React.FC<CategoryListProps> = ({ categories }) => {
  return (
    <Box>
      {categories.map((category) => (
        <Paper key={category.id} className='mb-2 p-2'>
          <Typography variant='h6'>{category.name}</Typography>
        </Paper>
      ))}
    </Box>
  );
};

export default CategoryList;
