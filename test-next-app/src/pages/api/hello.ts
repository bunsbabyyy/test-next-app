// Next.js API route support: https://nextjs.org/docs/api-routes/introduction
import type { NextApiRequest, NextApiResponse } from 'next'

type Data = {
  name: string
}

export async function getStaticProps() {
  const res = await fetch('https://api.example.com/data');
  const data = await res.json();

  console.log(data);
  return {
    props: {
      data,
    },
  }
};